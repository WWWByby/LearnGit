package main

import (
	"log"

	"github.com/micro/go-micro"
	proto "github.com/micro/examples/greeter/srv/proto/hello"

	"golang.org/x/net/context"
)

type Greeter struct{}

func (g *Greeter) Hello(ctx context.Context, req *proto.Request, rsp *proto.Response) error {
	rsp.Msg = "Hello " + req.Name
	return nil
}

func main() {
	service := micro.NewService(
		micro.Name("greeter"),
		micro.Version("latest"),
	)

	service.Init()

	proto.RegisterSayHandler(service.Server(), new(Greeter))

	if err := service.Run(); err != nil {
		log.Fatal(err)
	}
}