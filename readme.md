using https://github.com/bytecodealliance/componentize-dotnet?tab=readme-ov-file#referencing-wit-packages-from-oci-registries

```
dotnet build .\MyApp.csproj
wasmtime serve -S cli  .\bin\Debug\net8.0\wasi-wasm\native\MyApp.wasm --addr 127.0.0.1:3000
```