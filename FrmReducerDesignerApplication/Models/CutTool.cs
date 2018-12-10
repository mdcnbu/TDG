using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public class CutTool
    {
      public int Id { get; set; }
      public double  ScaleValue { get; set; }
      public int GearNum { get; set; }
      public double D0 { get; set; }
      public double Da0 { get; set; }
      public double Ha0 { get; set; }
      public string ToolStyle { get; set; }
    }
}
