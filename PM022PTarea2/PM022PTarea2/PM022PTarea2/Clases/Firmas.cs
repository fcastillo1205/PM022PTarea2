using System;
using System.Collections.Generic;
using System.Text;
using PM022PTarea2.Models;
using System.Threading.Tasks;

namespace PM022PTarea2.Clases
{
    class Firmas
    {
        ConexionDB conexion = new ConexionDB();

        public Task<List<Modelo>> getReadFirmas()
        {
            return conexion.getConnectionAsync().Table<Modelo>().ToListAsync();
        }

        public Task<Modelo> getFirmaId(int id)
        {
            return conexion.getConnectionAsync().Table<Modelo>().Where(item => item.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> updateFirma(Modelo firma)
        {
            return conexion.getConnectionAsync().UpdateAsync(firma);
        }

        public Task<int> delteFirma(Modelo firma)
        {
            return conexion.getConnectionAsync().DeleteAsync(firma);
        }
    }
}
