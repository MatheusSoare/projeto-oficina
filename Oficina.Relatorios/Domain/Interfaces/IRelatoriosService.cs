using Domain.Entities.DTOs;
using OfficeOpenXml;
using PdfSharp.Pdf;

namespace Domain.Interfaces
{
    public interface IRelatoriosService
    {
        ExcelPackage GerarNotaClienteXlsx(GerarNotaClienteDTO parametro);
        PdfDocument GerarNotaClientePdf(GerarNotaClienteDTO parametro);
    }
}
    