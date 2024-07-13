using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductRegistration.Domain.Dtos;

namespace ProductRegistration.Application.Commands.V1.ProductsDelete;

public class ProductsDeleteHeader : IRequestHandler<ProductDeleteRequestCommand, ProductDeleteResponseCommand>
{
    private readonly IMapper _mapper;

    public ProductsDeleteHeader(IMapper mapper)
    {
        _mapper = mapper;
    }

    public Task<ProductDeleteResponseCommand> Handle(ProductDeleteRequestCommand request, CancellationToken cancellationToken)
    {
        var productDto = _mapper.Map<ProductDto>(request);
        return Task.Run(() => new ProductDeleteResponseCommand
        {
            product = productDto
        });



// var valor = "(a*b)^(a/b)";
// var valor2 = "(a*b)^2.5698";
// var valor3 = "((a*b)^2.5698)^10";
// var valor4 = "((a*b)^2.5698)^10^(15*10)";

// valor = Converter(valor);
// valor2 = Converter(valor2);
// valor3 = Converter(valor3);
// valor4 = Converter(valor4);

// Console.WriteLine(valor);
// Console.WriteLine(valor2);
// Console.WriteLine(valor3);
// Console.WriteLine(valor4);

// static string Converter(string valor)
// {
//     while (valor.Contains("^"))
//     {
//         var indexValor = valor.IndexOf("^");
//         valor = valor.Remove(indexValor, 1);
//         valor = valor.Insert(indexValor, ",");

//         valor = AdicionandoValorDireita(ref valor, indexValor);
//         valor = AdicionandoValorEsquerda(ref valor, indexValor);
//     }

//     return valor;
// }


// static string AdicionandoValorEsquerda(ref string valor, int indexValor)
// {
//     indexValor--;
//     if (valor[indexValor].Equals(')'))
//     {
//         var fechamentoEsquerda = 0;
//         var AberturaEsquerda = 0;
//         for (int i = indexValor; i < valor.Length; i--)
//         {
//             if (valor[i].Equals(')'))
//             {
//                 fechamentoEsquerda++;
//                 AberturaEsquerda--;
//             }

//             if (valor[i].Equals('('))
//             {
//                 AberturaEsquerda++;
//                 fechamentoEsquerda--;
//             }

//             if (fechamentoEsquerda == AberturaEsquerda)
//             {
//                 valor = valor.Insert(i, "Pow(");
//                 break;
//             }
//         }
//     }
//     else
//     {
//         var regex = new Regex(@"[\*\/+-,)]");

//         var position = regex.Match(valor.Substring(0, indexValor)).Index;

//         if (position > 0)
//         {
//             valor = valor.Insert(indexValor-1, "Pow(");
//             return valor;
//         }
//         valor = valor.Insert(valor.Length, "Pow(");
//     }

//     return valor;
// }

// static string AdicionandoValorDireita(ref string valor, int indexValor)
// {
//     indexValor++;
//     if (valor[indexValor].Equals('('))
//     {
//         var aberturaDireita = 0;
//         var fechamentoDireita = 0;
//         for (int i = indexValor; i < valor.Length; i++)
//         {
//             if (valor[i].Equals('('))
//             {
//                 aberturaDireita++;
//                 fechamentoDireita--;
//             }

//             if (valor[i].Equals(')'))
//             {
//                 fechamentoDireita++;
//                 aberturaDireita--;
//             }

//             if (aberturaDireita == fechamentoDireita)
//             {
//                 valor = valor.Insert(i, ")");
//                 break;
//             }
//         }
//     }
//     else
//     {
//         if (!valor.Substring(indexValor).Contains(")"))
//         {
//             var regex = new Regex(@"[\*\/+-\^]");

//             var position = regex.Match(valor.Substring(indexValor)).Index;

//             if (position > 0)
//             {
//                 valor = valor.Insert(position + indexValor, ")");
//                 return valor;
//             }
//             valor = valor.Insert(valor.Length, ")");
//         }
//         else
//         {
//             for (int i = indexValor; i < valor.Length; i++)
//             {
//                 if (valor[i].Equals(')'))
//                 {
//                     valor = valor.Insert(i, ")");
//                     break;
//                 }
//             }
//         }
//     }

//     return valor;
// }
    }
}
