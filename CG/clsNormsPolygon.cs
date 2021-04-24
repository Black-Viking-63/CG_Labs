using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG
{
    public class clsNormsPolygon
    {

        public clsNorm[] norms = new clsNorm[3];

        public clsNormsPolygon()
        {
        }

        public clsNormsPolygon(clsNorm norm1, clsNorm norm2, clsNorm norm3)
        {
            this.norms[0] = norm1;
            this.norms[1] = norm2;
            this.norms[2] = norm3;
        }

        public clsNorm this[int index]
        {
            get
            {
                return norms[index];
            }
            set
            {
                norms[index] = value;
            }
        }
    }
}
