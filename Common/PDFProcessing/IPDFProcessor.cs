using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.PDFProcessing
{
    public interface IPDFProcessor
    {
        void generatePDF();

        void processPDF();
    }
}
