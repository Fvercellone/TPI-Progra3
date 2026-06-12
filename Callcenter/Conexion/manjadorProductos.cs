using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Dominio;

namespace Conexion
{
    public class manjadorProductos
    {
        /*public List<Producto> listar()
        {
            List<Producto> lista = new List<Producto>();
            ConexionDB conexion = new ConexionDB();
            try
            {
                // Include the IdMarca and IdCategoria in the query so they can be mapped to the Producto's Marca/Categoria objects
                conexion.settearConsulta("SELECT P.Id, P.Codigo, P.Nombre, P.Descripcion, P.IdMarca, P.IdCategoria, M.Descripcion as Marca, C.Descripcion as Categoria, I.ImagenUrl, P.Precio FROM dbo.articulos P LEFT JOIN dbo.imagenes I ON P.Id = I.Idarticulo LEFT JOIN dbo.marcas M ON M.Id = P.IdMarca LEFT JOIN dbo.categorias C ON C.Id = P.IdCategoria");
                conexion.ejecutarLectura();
                while (conexion._lector.Read())
                {
                    Producto aux = new Producto();

                    aux.Id = (int)conexion._lector["Id"];
                    aux.Codigo = (string)conexion._lector["Codigo"];
                    aux.Name = (string)conexion._lector["Nombre"];
                    aux.Description = (string)conexion._lector["Descripcion"];
                    aux.Marca = new Personas();
                    aux.Marca.idMarca = (int)conexion._lector["IdMarca"];
                    aux.Marca.Nombre = (string)conexion._lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.idCategoria = (int)conexion._lector["IdCategoria"];
                    aux.Categoria.Nombre = (string)conexion._lector["Categoria"];
                    if (conexion._lector["ImagenUrl"] != DBNull.Value)
                    {
                        aux.Imagen = (string)conexion._lector["ImagenUrl"];
                    }else
                    {
                        aux.Imagen = "n/a";
                    }
                    aux.Precio = (decimal)conexion._lector["Precio"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }

        public void agregar(Producto nuevo)
        {
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.settearConsulta("INSERT INTO dbo.articulos (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) VALUES (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio); DECLARE @IdArticulo INT = SCOPE_IDENTITY(); INSERT INTO dbo.imagenes (IdArticulo, ImagenUrl) VALUES (@IdArticulo, @ImagenUrl);");
                conexion.agregarParametro("@Codigo", nuevo.Codigo);
                conexion.agregarParametro("@Nombre", nuevo.Name);
                conexion.agregarParametro("@Descripcion", nuevo.Description);
                conexion.agregarParametro("@IdMarca", nuevo.Marca.idMarca);
                conexion.agregarParametro("@IdCategoria", nuevo.Categoria.idCategoria);
                conexion.agregarParametro("@ImagenUrl", nuevo.Imagen);
                conexion.agregarParametro("@Precio", nuevo.Precio);
                conexion.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }

        public void modificar(Producto producto)
        {
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.settearConsulta("BEGIN TRANSACTION; UPDATE ARTICULOS SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, Precio = @Precio WHERE Id = @Id; UPDATE IMAGENES SET ImagenUrl = @ImagenUrl WHERE IdArticulo = @Id; COMMIT");
                conexion.agregarParametro("@Id", producto.Id);
                conexion.agregarParametro("@Codigo", producto.Codigo);
                conexion.agregarParametro("@Nombre", producto.Name);
                conexion.agregarParametro("@Descripcion", producto.Description);
                conexion.agregarParametro("@IdMarca", producto.Marca.idMarca);
                conexion.agregarParametro("@IdCategoria", producto.Categoria.idCategoria);
                conexion.agregarParametro("@ImagenUrl", producto.Imagen);
                conexion.agregarParametro("@Precio", producto.Precio);
                conexion.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }

        public void Eliminar(int id)
        {
                ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.settearConsulta("DELETE FROM ARTICULOS WHERE Id = @Id");
                conexion.agregarParametro("@Id", id);
                conexion.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }

        
        */
        
    }
}
