﻿using BreakingGymWebDAL;
using BreakingGymWebEN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BreakinGymWebBL
{
    public class TipoDocumentoBL
    {
        public List<TipoDocumentoEN> MostrarTipoDocumento()
        {
            return TipoDocumentoDAL.MostrarTipoDocumento();
        }
        public int GuardarTipoDocumento(TipoDocumentoEN pTipoDocumentoEN)
        {
            return TipoDocumentoDAL.AgregarTipoDocumento(pTipoDocumentoEN);
        }
        public int EliminarTipoDocumento(TipoDocumentoEN pTipoDocumentoEN)
        {
            return TipoDocumentoDAL.EliminarTipoDocumento(pTipoDocumentoEN);
        }
        public int ModificarTipoDocumento(TipoDocumentoEN pTipoDocumentoEN)
        {
            return TipoDocumentoDAL.ModificarTipoDocumento(pTipoDocumentoEN);
        }
    }
}
