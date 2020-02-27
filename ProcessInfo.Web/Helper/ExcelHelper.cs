using OfficeOpenXml;
using ProcessInfo.Web.Models.DTOs.RequestDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessInfo.Web.Helper
{
    public class ExcelHelper
    {
        public static List<SaveUserRequestDTO> ReadExcelForBulkUploadUser(ExcelPackage package, ExcelWorksheet worksheet)
        {
            var data = new List<SaveUserRequestDTO>();

            var rowCount = worksheet.Dimension?.Rows;
            var colCount = worksheet.Dimension?.Columns;

            if (!rowCount.HasValue || !colCount.HasValue)
                return data;

            //We have some rows and columns. Start Reading them.
            for (int row = 2; row <= rowCount.Value; row++)
            {
                var user = new SaveUserRequestDTO();

                user.FirstName = worksheet.Cells[row, 1].Value?.ToString();
                user.MiddleName = worksheet.Cells[row, 2].Value?.ToString();
                user.LastName = worksheet.Cells[row, 3].Value?.ToString();
                user.Username = worksheet.Cells[row, 4].Value?.ToString();
                user.EmailAddress = worksheet.Cells[row, 5].Value?.ToString();
                user.Password = worksheet.Cells[row, 4].Value?.ToString();

                data.Add(user);
            }

            return data;
        }
    }
}
