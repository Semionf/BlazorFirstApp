using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorUploadFile7.Shared
{
    public class JSStorage
    {
        public IJSRuntime jsRuntime;

        public IJSRuntime JSRuntime
        {
            get
            {
                return jsRuntime;
            }
        }

        public JSStorage(IJSRuntime js)
        {
            jsRuntime = js;
        }

        public async Task Save(string name, string val)
        {
            await JSRuntime.InvokeVoidAsync("localStorage.setItem", name, val);
        }

        public async Task<string> Read (string name)
        {
            string res = await JSRuntime.InvokeAsync<string>("localStorage.getItem", name);
            return res;
        }

        public async void Delete(string name)
        {
            await JSRuntime.InvokeAsync<string>("localStorage.removeItem", name);
        }
    }
}
