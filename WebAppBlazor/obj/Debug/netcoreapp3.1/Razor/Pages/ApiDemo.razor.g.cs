#pragma checksum "D:\ПОИС\Веб\WebApp\WebAppBlazor\Pages\ApiDemo.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b2edf544c878d54b77bb1b6373c67fbcd98ab29a"
// <auto-generated/>
#pragma warning disable 1591
namespace WebAppBlazor.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 2 "D:\ПОИС\Веб\WebApp\WebAppBlazor\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\ПОИС\Веб\WebApp\WebAppBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\ПОИС\Веб\WebApp\WebAppBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\ПОИС\Веб\WebApp\WebAppBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\ПОИС\Веб\WebApp\WebAppBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\ПОИС\Веб\WebApp\WebAppBlazor\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\ПОИС\Веб\WebApp\WebAppBlazor\_Imports.razor"
using WebAppBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\ПОИС\Веб\WebApp\WebAppBlazor\_Imports.razor"
using WebAppBlazor.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\ПОИС\Веб\WebApp\WebAppBlazor\Pages\ApiDemo.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\ПОИС\Веб\WebApp\WebAppBlazor\Pages\ApiDemo.razor"
using WebAppBlazor.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\ПОИС\Веб\WebApp\WebAppBlazor\Pages\ApiDemo.razor"
using WebAppBlazor.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\ПОИС\Веб\WebApp\WebAppBlazor\Pages\ApiDemo.razor"
using System.Text.Json;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/apidemo")]
    public partial class ApiDemo : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "container");
            __builder.AddMarkupContent(2, "\r\n    ");
            __builder.OpenComponent<WebAppBlazor.Components.CertificateList>(3);
            __builder.AddAttribute(4, "SelectedObjectChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Int32>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Int32>(this, 
#nullable restore
#line 9 "D:\ПОИС\Веб\WebApp\WebAppBlazor\Pages\ApiDemo.razor"
                                                                              ShowDetails

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(5, "Certificates", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.IEnumerable<WebAppBlazor.Data.CertificateListViewModel>>(
#nullable restore
#line 9 "D:\ПОИС\Веб\WebApp\WebAppBlazor\Pages\ApiDemo.razor"
                                         certificates

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(6, "CertificatesChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Collections.Generic.IEnumerable<WebAppBlazor.Data.CertificateListViewModel>>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Collections.Generic.IEnumerable<WebAppBlazor.Data.CertificateListViewModel>>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => certificates = __value, certificates))));
            __builder.CloseComponent();
            __builder.AddMarkupContent(7, "\r\n    ");
            __builder.OpenComponent<WebAppBlazor.Components.CertificateDetails>(8);
            __builder.AddAttribute(9, "Certificate", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<WebAppBlazor.Data.CertificateDetailsViewModel>(
#nullable restore
#line 10 "D:\ПОИС\Веб\WebApp\WebAppBlazor\Pages\ApiDemo.razor"
                                           SelectedCertificate

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(10, "CertificateChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<WebAppBlazor.Data.CertificateDetailsViewModel>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<WebAppBlazor.Data.CertificateDetailsViewModel>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => SelectedCertificate = __value, SelectedCertificate))));
            __builder.CloseComponent();
            __builder.AddMarkupContent(11, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 13 "D:\ПОИС\Веб\WebApp\WebAppBlazor\Pages\ApiDemo.razor"
       
    public IEnumerable<CertificateListViewModel> certificates { get; set; }

    string apiBaseAddress = "https://localhost:44392/Api/Certificates";

    protected override async Task OnInitializedAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, apiBaseAddress);
        var client = clientFactory.CreateClient();
        var response = await client.SendAsync(request);//client.GetAsync(apiBaseAddress);
        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            certificates = await JsonSerializer.DeserializeAsync<IEnumerable<CertificateListViewModel>>(responseStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }

    [Parameter]
    public CertificateDetailsViewModel SelectedCertificate { get; set; }
    private async Task ShowDetails(int id)
    {
        var client = clientFactory.CreateClient();
        var response = await client.GetAsync(apiBaseAddress + $"/{id}");
        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            SelectedCertificate = await
        JsonSerializer.DeserializeAsync<CertificateDetailsViewModel>(responseStream);
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IHttpClientFactory clientFactory { get; set; }
    }
}
#pragma warning restore 1591
