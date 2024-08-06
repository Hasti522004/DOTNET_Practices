using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordDemo
{
    // bellow both are same;
    public record PersonforRecord(string Fullname, DateOnly DOB);

    public record Person1forRecord
    {
        public string Fullname { get; init; } = default!;
        public DateOnly DOB { get; init; } = default!;
    }

    public record struct PersonasStruct(string FullName, DateOnly DOB);

    public class Person1asClass
    {
        public string Fullname { get; init; } = default!;
        public DateOnly DOB { get; init; } = default!;
    }
}