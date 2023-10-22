using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessApp.Core.Validators.Interfaces;

namespace FitnessApp.Core.Validators
{
    public class ResponseContext<T> : IResponseContext<T>
    {
        public int StatusCode { get; set; }
        public string? StatusMessage { get; set; }
        public T? Response { get; set; }

    }
}
