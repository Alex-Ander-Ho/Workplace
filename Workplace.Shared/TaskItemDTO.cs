using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Workplace.Shared
{
    public class TaskItemDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Требуется указать название")]
        [Display(Name = "Наименование")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Требуется дать описание")]
        [Display(Name = "Описание")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Требуется указать время начала")]
        [DateMustBeBefore(nameof(EndTime))]
        [Display(Name = "Время начала")]
        public DateTime? StartTime { get; set; }

        [Required(ErrorMessage = "Требуется указать время окончания")]
        [DateMustBeAfter(nameof(StartTime))]
        [Display(Name = "Время окончания")]
        public DateTime? EndTime { get; set; }

        [Required(ErrorMessage = "Требуется указать место проведения")]
        [Display(Name = "Место проведения")]
        public string? Location { get; set; }

        [Required(ErrorMessage = "Требуется указать преподавателя")]
        [Display(Name = "Преподаватель")]
        public string? Teacher { get; set; }

        public bool IsFavorite { get; set; } = false;
    }
}
