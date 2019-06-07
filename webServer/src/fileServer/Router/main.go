package Router

import (
	"bytes"
	"fileServer/config"
	"fmt"
	"github.com/gorilla/mux"
	"github.com/liangdas/mqant/log"
	"io/ioutil"
	"net/http"
	"path"
)

var routerMain = mux.NewRouter()

func SetUp() *mux.Router {

	routerMain.HandleFunc("/assetBundle", func(writer http.ResponseWriter, request *http.Request) {
		fmt.Println(request.Header, request.Body)
	}).Methods("GET")

	route := routerMain.HandleFunc("/", func(writer http.ResponseWriter, request *http.Request) {
		bf := bytes.Buffer{}
		bf.WriteString("Hello,World")
		_, _ = writer.Write(bf.Bytes())
	}).Queries("id", "{id}")

	routerMain.Use(func(handler http.Handler) http.Handler {
		return http.HandlerFunc(func(w http.ResponseWriter, r *http.Request) {
			fmt.Println(r.RequestURI)
			fmt.Println(mux.Vars(r))
			fmt.Println(r.Body)
			handler.ServeHTTP(w, r)
			//http.Error(w, "Forbidden", http.StatusForbidden)
		})
	})

	conf := config.GetConfig()

	routerMain.HandleFunc("/Platform", func(writer http.ResponseWriter, request *http.Request) {
		bf := bytes.Buffer{}

		dir := path.Dir(conf.Path)
		files, err := ioutil.ReadDir(dir)
		if err != nil {
			log.Error("read dir %v : %v", dir, err)
		}

		fileListStr := ""

		for _, file := range files {
			fileListStr += file.Name() + "\n"
		}
		bf.WriteString(fileListStr)
		_, _ = writer.Write(bf.Bytes())
	}).Methods("GET")

	route.Methods("GET")
	return routerMain
}
