package main

import (
	"fileServer/Router"
	"fileServer/config"
	"fmt"
	"net/http"
	"os"
	"os/signal"
	"time"
)

var conf *config.FileServerConfig

func main() {
	conf = config.GetConfig()
	loop()
}

func loop() {
	r := Router.SetUp()
	svr := http.Server{
		Addr:         fmt.Sprintf(":%v", conf.Port),
		ReadTimeout:  3 * time.Second,
		WriteTimeout: 3 * time.Second,
		Handler:      r,
	}

	go func() {
		println("visit http:127.0.0.1" + svr.Addr)
		_ = svr.ListenAndServe()
	}()

	s := wait(os.Interrupt, os.Kill)
	_ = svr.Close()
	//svr.Shutdown()
	fmt.Printf("Got signal `%v`", s)
}

func wait(signals ...os.Signal) os.Signal {
	c := make(chan os.Signal, 1)
	signal.Notify(c, signals...)
	s := <-c
	return s
}
