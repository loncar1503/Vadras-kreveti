using System;
using System.Globalization;
using System.IO;
using API_Vadras.DTO.Porudzbina;
using API_Vadras.DTO.StavkaPorudzbine;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

public class RacunPorudzbinaDocument : IDocument
{
    private readonly VratiPorudzbinuDTO _porudzbina;
    private readonly string? _headerImagePath;
    private readonly string? _footerImagePath;

    public RacunPorudzbinaDocument(
        VratiPorudzbinuDTO porudzbina,
        string? headerImagePath = null,
        string? footerImagePath = null)
    {
        _porudzbina = porudzbina;

        var baseDir = AppDomain.CurrentDomain.BaseDirectory;

        var defaultHeader = Path.Combine(baseDir, "Resources", "MemorandumHeader.jpg");
        var defaultFooter = Path.Combine(baseDir, "Resources", "MemorandumFooter.jpg");

        if (string.IsNullOrWhiteSpace(headerImagePath))
            headerImagePath = defaultHeader;

        if (string.IsNullOrWhiteSpace(footerImagePath))
            footerImagePath = defaultFooter;

        if (!string.IsNullOrWhiteSpace(headerImagePath) && File.Exists(headerImagePath))
            _headerImagePath = headerImagePath;

        if (!string.IsNullOrWhiteSpace(footerImagePath) && File.Exists(footerImagePath))
            _footerImagePath = footerImagePath;
    }

    public DocumentMetadata GetMetadata() => new DocumentMetadata
    {
        Title = $"Račun {_porudzbina.BrRacuna}",
        Author = "VADRAS"
    };

    // NOVI API – umesto GetDefinition
    public void Compose(IDocumentContainer container)
    {
        var culture = new CultureInfo("sr-Latn-RS");
        const decimal pdvStopa = 0.20m;

        // prilagodi polja po svom DTO-u
        decimal Osnovica(UcitajStavkePorudzbineDTO s) => (decimal)(s.Kolicina * s.FinalnaCena);
        decimal IznosPdv(UcitajStavkePorudzbineDTO s) => Math.Round(Osnovica(s) * pdvStopa, 2);
        decimal Vrednost(UcitajStavkePorudzbineDTO s) => Osnovica(s) + IznosPdv(s);

        decimal ukupnaOsnovica = 0;
        decimal ukupnoPdv = 0;
        decimal ukupnoSaPdv = 0;

        foreach (var s in _porudzbina.Stavke)
        {
            var osnovica = Osnovica(s);
            var pdv = IznosPdv(s);
            var vrednost = Vrednost(s);

            ukupnaOsnovica += osnovica;
            ukupnoPdv += pdv;
            ukupnoSaPdv += vrednost;
        }

        string FormatDecimal(decimal value) => value.ToString("#,0.00", culture);

        container.Page(page =>
        {
            page.Size(PageSizes.A4);
            page.Margin(20);
            page.DefaultTextStyle(x => x.FontSize(9));

            page.Header().Element(BuildHeader);
            page.Content().Element(BuildContent);
            page.Footer().Element(BuildFooter);

            void BuildHeader(IContainer containerHeader)
            {
                containerHeader.Column(col =>
                {
                    if (!string.IsNullOrEmpty(_headerImagePath))
                    {
                        col.Item()
                           .Image(_headerImagePath)
                           .FitWidth();   // sada je visina slike ionako mala
                    }

                    col.Item().PaddingTop(5).Row(row =>
                    {
                        // kupac
                        row.RelativeItem(2).Border(1).Padding(5).Column(c =>
                        {
                            c.Item().Text(_porudzbina.ImePrezime).Bold();
                            c.Item().Text(_porudzbina.Adresa);
                            c.Item().Text(_porudzbina.BrojTelefona);
                        });

                        // računi i datumi
                        row.RelativeItem(1).AlignRight().Column(c =>
                        {
                            c.Item().Text(t =>
                            {
                                t.Span("RAČUN ").Bold();
                                t.Span(_porudzbina.BrRacuna).Bold();
                            });

                            c.Item().Text(text =>
                            {
                                text.Span("Datum izdavanja: ").Bold();
                                text.Span(_porudzbina.DatumPorudzbine.ToString("dd.MM.yyyy.", culture));
                            });

                            c.Item().Text(text =>
                            {
                                text.Span("Datum isporuke: ").Bold();
                                text.Span(_porudzbina.DatumIsporuke.ToString("dd.MM.yyyy.", culture));
                            });
                        });
                    });

                    col.Item().PaddingTop(10).Row(row =>
                    {
                        row.RelativeItem().Column(c =>
                        {
                            c.Item().Text("NAČIN PLAĆANJA").Bold();
                            c.Item().Text("gotovina");
                        });

                        row.RelativeItem().AlignCenter().Column(c =>
                        {
                            c.Item().Text("MESTO I DATUM PROMETA DOBARA I USLUGA").Bold();
                            c.Item().Text(text =>
                            {
                                text.Span("Beograd, ");
                                text.Span(_porudzbina.DatumIsporuke.ToString("dd.MM.yyyy.", culture)).Bold();
                            });
                        });

                        row.RelativeItem().AlignRight().Column(c =>
                        {
                            c.Item().Text("Radnik:").Bold();
                            c.Item().Text(_porudzbina.RadnikImePrezime);
                        });
                    });
                });
            }

            void BuildContent(IContainer containerContent)
            {
                containerContent.PaddingTop(10).Column(col =>
                {
                    // tabela
                    col.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(20);   // RB
                            columns.RelativeColumn(3);    // Artikal
                            columns.RelativeColumn(2);    // Dimenzija
                            columns.RelativeColumn(2);    // Boja
                            columns.RelativeColumn(1);    // Količina
                            columns.RelativeColumn(2);    // Jed. cena
                            columns.RelativeColumn(2);    // Osnovica PDV
                            columns.ConstantColumn(35);   // Stopa
                            columns.RelativeColumn(2);    // Iznos PDV
                            columns.RelativeColumn(2);    // Vrednost
                        });

                        table.Header(header =>
                        {
                            header.Cell().Element(HeaderCell).Text("RB");
                            header.Cell().Element(HeaderCell).Text("ARTIKAL");
                            header.Cell().Element(HeaderCell).Text("DIMENZIJA");
                            header.Cell().Element(HeaderCell).Text("BOJA");
                            header.Cell().Element(HeaderCell).Text("KOL.");
                            header.Cell().Element(HeaderCell).Text("JEDINIČNA CENA");
                            header.Cell().Element(HeaderCell).Text("OSNOVICA PDV");
                            header.Cell().Element(HeaderCell).Text("STOPA PDV");
                            header.Cell().Element(HeaderCell).Text("IZNOS PDV");
                            header.Cell().Element(HeaderCell).Text("VREDNOST");
                        });

                        int rb = 1;
                        foreach (var s in _porudzbina.Stavke)
                        {
                            var osnovica = Osnovica(s);
                            var pdv = IznosPdv(s);
                            var vrednost = Vrednost(s);

                            table.Cell().Element(Cell).Text(rb++.ToString());
                            table.Cell().Element(Cell).Text(s.Proizvod.Naziv);   // prilagodi po DTO-u
                            table.Cell().Element(Cell).Text(s.Dimenzija);
                            table.Cell().Element(Cell).Text(s.Boja);
                            table.Cell().Element(Cell).AlignRight().Text(s.Kolicina.ToString());
                            table.Cell().Element(Cell).AlignRight().Text(FormatDecimal((decimal)s.FinalnaCena));
                            table.Cell().Element(Cell).AlignRight().Text(FormatDecimal(osnovica));
                            table.Cell().Element(Cell).AlignRight().Text("20%");
                            table.Cell().Element(Cell).AlignRight().Text(FormatDecimal(pdv));
                            table.Cell().Element(Cell).AlignRight().Text(FormatDecimal(vrednost));
                        }

                        static IContainer HeaderCell(IContainer container) =>
                            container.Border(1)
                                     .Background(Colors.Grey.Lighten3)
                                     .Padding(3)
                                     .AlignCenter()
                                     .AlignMiddle();

                        static IContainer Cell(IContainer container) =>
                            container.BorderBottom(1)
                                     .PaddingVertical(2)
                                     .PaddingHorizontal(2);
                    });

                    // napomene
                    col.Item().PaddingTop(10).Column(c =>
                    {
                        c.Item().Text("Napomene:").Bold();
                        if (!string.IsNullOrWhiteSpace(_porudzbina.Napomena))
                            c.Item().Text(_porudzbina.Napomena);
                        else
                            c.Item().Text("-");
                    });

                    // dodatne info
                    col.Item().PaddingTop(5).Column(c =>
                    {
                        var list = new System.Collections.Generic.List<string>();
                        if (_porudzbina.Stan) list.Add("isporuka u stan");
                        if (_porudzbina.Lift) list.Add("zgrada ima lift");
                        if (_porudzbina.AparatZaKartice) list.Add("aparat za kartice");

                        if (list.Count > 0)
                            c.Item().Text("Dodatne informacije: " + string.Join(", ", list));
                    });

                    // sumarni deo
                    col.Item().PaddingTop(15).Row(row =>
                    {
                        row.RelativeItem();

                        row.ConstantItem(230).Table(t =>
                        {
                            t.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(2);
                            });

                            t.Cell().Element(SummaryLabel).Text("OSNOVICA");
                            t.Cell().Element(SummaryValue).AlignRight().Text(FormatDecimal(ukupnaOsnovica));

                            t.Cell().Element(SummaryLabel).Text("IZNOS PDV");
                            t.Cell().Element(SummaryValue).AlignRight().Text(FormatDecimal(ukupnoPdv));

                            t.Cell().Element(SummaryLabel).Text("VREDNOST SA PDV-om");
                            t.Cell().Element(SummaryValue).AlignRight().Text(FormatDecimal(ukupnoSaPdv));

                            t.Cell().Element(SummaryLabel).Text("AVANS");
                            t.Cell().Element(SummaryValue).AlignRight().Text(FormatDecimal(0m));

                            t.Cell().Element(SummaryLabel).Text("ZA NAPLATU").Bold();
                            t.Cell().Element(SummaryValue).AlignRight().Text(FormatDecimal(ukupnoSaPdv)).Bold();

                            static IContainer SummaryLabel(IContainer c2) =>
                                c2.Border(1)
                                  .Background(Colors.Grey.Lighten3)
                                  .Padding(3);

                            static IContainer SummaryValue(IContainer c2) =>
                                c2.Border(1)
                                  .Padding(3);
                        });
                    });

                    // potpisi
                    col.Item().PaddingTop(25).Row(row =>
                    {
                        row.RelativeItem().Column(c =>
                        {
                            c.Item().Text("Fakturisao:").Bold();
                            c.Item().Text(_porudzbina.RadnikImePrezime);
                            c.Item().PaddingTop(20).Text("s.r.");
                        });

                        row.RelativeItem().AlignRight().Column(c =>
                        {
                            c.Item().Text("Kupac:").Bold();
                            c.Item().Text(_porudzbina.ImePrezime);
                            c.Item().PaddingTop(20).Text("s.r.");
                        });
                    });
                });
            }

            void BuildFooter(IContainer containerFooter)
            {
                containerFooter.Column(c =>
                {
                    if (!string.IsNullOrEmpty(_footerImagePath))
                    {
                        c.Item()
                         .Image(_footerImagePath)
                         .FitWidth();
                    }

                    c.Item().AlignCenter().Text("Preduzeće za trgovinu i usluge VADRAS doo,  reg. br. 217413/2006,  šifra delatnosti 4759,       e-mail office@vadras.rs").FontSize(7);
                });
            }
        });
    }
}