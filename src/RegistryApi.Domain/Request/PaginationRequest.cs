using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryApi.Domain.Request
{
    public class PaginationRequest
    {
        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int Page { get; set; } = 1;
        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int PerPage { get; set; } = 10;
    }
}
