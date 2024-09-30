using DL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Entities;

public class Medication : BaseEntity
{
    public string Name { get; set; } =String.Empty;
    public string Dosage { get; set; } = String.Empty;
}
