using Domain.Entities.DTOs;
using Domain.Interfaces;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Diagnostics;
using System.Drawing;
using System.Text;

namespace Domain.Services
{
    public class RelatoriosService : IRelatoriosService
    {
        public ExcelPackage GerarNotaClienteXlsx(GerarNotaClienteDTO parametro)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var excelPkg = new ExcelPackage();
            var ws = excelPkg.Workbook.Worksheets.Add("report");
            var linha = 1;

            ws.Cells.Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells.Style.Fill.BackgroundColor.SetColor(Color.White);
            ws.Cells.Style.Font.Name = "Arial";
            ws.Cells.Style.Font.Size = 10;

            CriarCabecalho(ws.Cells[linha, 1]);
            CriarCabecalho(ws.Cells[linha, 2]);

            ws.Cells[linha, 1].Value = "Cliente";
            ws.Cells[linha, 2].Value = "CPF";

            linha++;

            ws.Cells[linha, 1].Value = parametro.Cliente.Nome;
            ws.Cells[linha, 2].Value = parametro.Cliente.CpfFormatado;

            linha += 2;

            CriarCabecalho(ws.Cells[linha, 1]);
            CriarCabecalho(ws.Cells[linha, 2]);
            CriarCabecalho(ws.Cells[linha, 3]);
            CriarCabecalho(ws.Cells[linha, 4]);

            ws.Cells[linha, 1].Value = "Marca";
            ws.Cells[linha, 2].Value = "Modelo";
            ws.Cells[linha, 3].Value = "Ano";
            ws.Cells[linha, 4].Value = "Placa";

            linha++;

            ws.Cells[linha, 1].Value = parametro.Carro.Marca;
            ws.Cells[linha, 2].Value = parametro.Carro.Modelo;
            ws.Cells[linha, 3].Value = parametro.Carro.Ano;
            ws.Cells[linha, 4].Value = parametro.Carro.Placa;

            linha += 2;

            CriarCabecalho(ws.Cells[linha, 1]);
            CriarCabecalho(ws.Cells[linha, 2]);

            ws.Cells[linha, 1].Value = "Descrição";
            ws.Cells[linha, 2].Value = "Valor";

            linha++;

            foreach (var item in parametro.Servicos) 
            {
                ws.Cells[linha, 1].Value = item.Descricao;
                ws.Cells[linha, 2].Value = $"R$ {item.Valor}";

                linha++;
            }

            linha++;

            CriarCabecalho(ws.Cells[linha, 1]);

            ws.Cells[linha, 1].Value = "Valor total";

            linha++;

            ws.Cells[linha, 1].Value = $"R$ {parametro.ValorTotal}";

            return excelPkg;
        }

        private void CriarCabecalho(ExcelRange ws)
        {
            ws.Style.Font.Color.SetColor(Color.White);
            ws.Style.Font.Bold = true;
            ws.Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Style.Fill.BackgroundColor.SetColor(Color.Orange);
        }

        public PdfDocument GerarNotaClientePdf(GerarNotaClienteDTO parametro)
        {
            PdfDocument document = new PdfDocument();
            document.Info.Title = $"Nota de Serviço - Cliente: {parametro.Cliente.NomeFormatado}";

            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont font = new XFont("Verdana", 12);
            XFont fontBold = new XFont("Verdana", 12);

            return document;
        }
    }
}
