package config

var conf *FileServerConfig

func GetConfig() *FileServerConfig {
	conf = &FileServerConfig{}
	ParseJson("./config/config.json", conf)
	return conf
}
