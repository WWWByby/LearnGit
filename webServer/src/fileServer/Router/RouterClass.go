package Router

import (
	"github.com/gorilla/mux"
	"net/http"
)

type BaseRouter struct {
	/**
	router methods;
	*/
	Methods  []string
	Path     string
	CallBack func(http.ResponseWriter,
		*http.Request)
}

type AssetBundleRouter struct {
	BaseRouter
}

func (self *BaseRouter) RegisterRouter() *mux.Route {
	return routerMain.HandleFunc(self.Path, self.CallBack).Methods(self.Methods...)
}
