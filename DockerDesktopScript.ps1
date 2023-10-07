docker rm --force $(docker ps -a -q -f name=TextEncryption)              # zkontroluje zda existuje kontejner a pokud ano, tak vrátí jeho číslo a pak kontejner v případě že běží zastaví příkazem force a poté příkazem rm kontejner vymaže
docker rmi $(docker images -q textencryption)                            # zkontroluje zda existuje image a pokud ano tak vrátí jeho číslo a pak image příkazem rmi vymaže
docker build --tag textencryption --file .\TextEncryption\Dockerfile .   # sestaví image
docker run -d --name TextEncryption -p 8000:80 textencryption            # spustí kontejner

docker save --output C:\DockerImages\textencryption.tar textencryption   # uloží kopii image pro nasazení aplikace v NASu