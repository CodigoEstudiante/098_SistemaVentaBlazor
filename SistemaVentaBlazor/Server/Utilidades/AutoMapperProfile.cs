using AutoMapper;
using SistemaVentaBlazor.Server.Models;
using SistemaVentaBlazor.Shared;
using System.Globalization;

namespace SistemaVentaBlazor.Server.Utilidades
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {

            #region Rol
            CreateMap<Rol, RolDTO>().ReverseMap();
            #endregion Rol

            #region Usuario
            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(destino =>
                    destino.rolDescripcion,
                    opt => opt.MapFrom(origen => origen.IdRolNavigation.Descripcion)
                );

            CreateMap<UsuarioDTO, Usuario>()
            .ForMember(destino =>
                destino.IdRolNavigation,
                opt => opt.Ignore()
            );

            CreateMap<UsuarioDTO, Usuario>()
                .ForMember(destino =>
                    destino.EsActivo,
                    opt => opt.MapFrom(src => true)
                );
            #endregion Usuario

            #region Categoria
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            #endregion Categoria

            #region Producto
            CreateMap<Producto, ProductoDTO>()
            .ForMember(destino =>
                destino.DescripcionCategoria,
                opt => opt.MapFrom(origen => origen.IdCategoriaNavigation.Descripcion)
            );
            //.ForMember(destino =>
            //    destino.Precio,
            //    opt => opt.MapFrom(origen => Convert.ToString(origen.Precio.Value, new CultureInfo("es-PE")))
            //);

            CreateMap<ProductoDTO, Producto>()
            .ForMember(destino =>
                destino.IdCategoriaNavigation,
                opt => opt.Ignore()
            );
            //.ForMember(destiono =>
            //    destiono.Precio,
            //    opt => opt.MapFrom(origen => Convert.ToDecimal(origen.Precio, new CultureInfo("es-PE")))
            //);
            #endregion Producto

            #region Venta
            CreateMap<Venta, VentaDTO>();
            //CreateMap<Venta, VentaDTO>()
            //    .ForMember(destino =>
            //        destino.TotalTexto,
            //        opt => opt.MapFrom(origen => Convert.ToString(origen.Total.Value, new CultureInfo("es-PE")))
            //    ).ForMember(destino =>
            //        destino.FechaRegistro,
            //        opt => opt.MapFrom(origen => origen.FechaRegistro.Value.ToString("dd/MM/yyyy"))
            //    );
            CreateMap<VentaDTO, Venta>();
            //CreateMap<VentaDTO, Venta>()
            //    .ForMember(destino =>
            //        destino.Total,
            //        opt => opt.MapFrom(origen => Convert.ToDecimal(origen.TotalTexto, new CultureInfo("es-PE")))
            //    );

            #endregion Venta

            #region DetalleVenta
            CreateMap<DetalleVenta, DetalleVentaDTO>()
                .ForMember(destino =>
                    destino.DescripcionProducto,
                    opt => opt.MapFrom(origen => origen.IdProductoNavigation.Nombre)
                );
            //.ForMember(destino =>
            //    destino.PrecioTexto,
            //    opt => opt.MapFrom(origen => Convert.ToString(origen.Precio.Value, new CultureInfo("es-PE")))
            //)
            //.ForMember(destino =>
            //    destino.TotalTexto,
            //    opt => opt.MapFrom(origen => Convert.ToString(origen.Total.Value, new CultureInfo("es-PE")))
            //);
            CreateMap<DetalleVentaDTO, DetalleVenta>();

            //CreateMap<DetalleVentaDTO, DetalleVenta>()
            //    .ForMember(destino =>
            //        destino.Precio,
            //        opt => opt.MapFrom(origen => Convert.ToDecimal(origen.PrecioTexto, new CultureInfo("es-PE")))
            //    )
            //    .ForMember(destino =>
            //        destino.Total,
            //        opt => opt.MapFrom(origen => Convert.ToDecimal(origen.TotalTexto, new CultureInfo("es-PE")))
            //    );
            #endregion

            #region Reporte
            CreateMap<DetalleVenta, ReporteDTO>()
                .ForMember(destino =>
                    destino.FechaRegistro,
                    opt => opt.MapFrom(origen => origen.IdVentaNavigation.FechaRegistro.Value.ToString("dd/MM/yyyy"))
                )
                .ForMember(destino =>
                    destino.NumeroDocumento,
                    opt => opt.MapFrom(origen => origen.IdVentaNavigation.NumeroDocumento)
                )
                .ForMember(destino =>
                    destino.TipoPago,
                    opt => opt.MapFrom(origen => origen.IdVentaNavigation.TipoPago)
                )
                .ForMember(destino =>
                    destino.TotalVenta,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.IdVentaNavigation.Total.Value, new CultureInfo("es-PE")))
                )
                .ForMember(destino =>
                    destino.Producto,
                    opt => opt.MapFrom(origen => origen.IdProductoNavigation.Nombre)
                )
                .ForMember(destino =>
                    destino.Precio,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.Precio.Value, new CultureInfo("es-PE")))
                )
                .ForMember(destino =>
                    destino.Total,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.Total.Value, new CultureInfo("es-PE")))
                );
            #endregion Reporte
        }
    }
}
