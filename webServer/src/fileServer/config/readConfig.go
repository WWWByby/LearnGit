package config

import (
	"encoding/json"
	"fmt"
	"io/ioutil"
)

type FileServerConfig struct {
	Port int
	Path string
}

func ParseJson(fileName string, v interface{}) {
	data, err := ioutil.ReadFile(fileName)

	if err != nil {
		fmt.Println(err)
		return
	}

	err = json.Unmarshal(data, v)
	if err != nil {
		fmt.Println(err)
		return
	}
}
