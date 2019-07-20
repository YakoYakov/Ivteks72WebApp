using System;
using System.Collections.Generic;
using System.Text;

namespace Ivteks72.Domain
{
    public class ClothingDiagram
    {
        public ClothingDiagram()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string DiagramAndCuttingPatternLinkToPictures { get; set; }
    }
}
