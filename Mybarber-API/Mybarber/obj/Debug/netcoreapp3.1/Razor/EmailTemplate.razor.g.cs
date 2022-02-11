#pragma checksum "C:\Users\User\source\repos\Mybarber-API\Mybarber\EmailTemplate.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "069b4c1287fa2aaf0a90a6cc52b90f1200fd8faf"
// <auto-generated/>
#pragma warning disable 1591
namespace Mybarber
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    public partial class EmailTemplate : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, @"<style>
   


    span {
        font-weight: bold;
    }

    .header {
        background-color: #202020;
        background-image: linear-gradient(to top left, rgb(0, 0, 0), #444444);
        border-radius: 10px 10px 0 0;
        padding: .5rem;
        display: flex;
        justify-content: center;
        text-align: center;
        width: 15.4rem;
    }

    .header h1 {
        width: 15.4rem;
        color: #fff;
        font-family: 'Quicksand', sans-serif;
        font-weight: 20;
        font-size: 1rem;
        text-align: center;
        border-bottom: 1px solid #B78865;
    }

    .content {
        width: 15.4rem;
        font-family: 'Roboto', sans-serif;
        font-weight: 20rem;
        font-size: .7rem;
        padding: .5rem;
        text-align: center;

    }

    .footer {
        background-color: #B78865;
        background-image: linear-gradient(to top left, #d1996e, #B78865);
        font-family: 'Roboto', sans-serif;
        font-size: .6rem;
        text-align: center;
        padding: .5rem;
        width: 15.4rem;
        border-radius: 0 0 10px 10px;
        
    }


</style>

");
            __builder.AddMarkupContent(1, "<div class=\"header\">\r\n    <h1>Agendamento Realizado com Sucesso</h1>\r\n</div>\r\n\r\n");
            __builder.AddMarkupContent(2, "<div class=\"content\">\r\n    <p>Olá, <span>{name}!</span></p>\r\n    <p>Seu agendamento com o barbeiro <span>{nameBarbeiro}</span> às <span>{horas}h</span> do dia <span>{dia}</span> foi realizado com sucesso.</p>\r\n</div>\r\n\r\n");
            __builder.AddMarkupContent(3, "<div class=\"footer\">\r\n    <p>Obrigado por agendar na <span>{nomeBarbearia}.</span></p>\r\n</div>");
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
