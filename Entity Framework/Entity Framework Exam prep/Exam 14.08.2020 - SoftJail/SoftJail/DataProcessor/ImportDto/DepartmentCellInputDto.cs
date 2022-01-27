
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    public class DepartmentCellInputDto
    {
        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string Name { get; set; }

        public List<CellInputDto> Cells { get; set; }

    }
    public class CellInputDto
    {
        [Range(1, 1000)]
        public int CellNUmber { get; set; }

        public bool HasWindow { get; set; }
    }
}
