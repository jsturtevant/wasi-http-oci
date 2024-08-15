using System.Text;
using ProxyWorld.wit.imports.wasi.http.v0_2_0;

namespace ProxyWorld.wit.exports.wasi.http.v0_2_0;

public class IncomingHandlerImpl: IIncomingHandler {
    public static void Handle(ITypes.IncomingRequest request, ITypes.ResponseOutparam responseOut) {
	var content = Encoding.ASCII.GetBytes("Hello, World!");
	var headers = new List<(string, byte[])> {
	    ("content-type", Encoding.ASCII.GetBytes("text/plain")),
	    ("content-length", Encoding.ASCII.GetBytes(content.Count().ToString()))
	};
	var response = new ITypes.OutgoingResponse(ITypes.Fields.FromList(headers));
	var body = response.Body();
	ITypes.ResponseOutparam.Set(responseOut, Result<ITypes.OutgoingResponse, ITypes.ErrorCode>.ok(response));
	using (var stream = body.Write()) {
	    stream.BlockingWriteAndFlush(content);
	}
	ITypes.OutgoingBody.Finish(body, null);
    }
}