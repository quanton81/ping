# Kubernetes

## .Net SDK, Runtime

[Install .Net](https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu "Install .Net")


## Docker

[Install docker](https://docs.docker.com/engine/install/ubuntu/ "Install docker")

### Execute docker with your user

```
sudo groupadd docker
sudo usermod -aG docker $USER
newgrp docker
```

### Build and push app

```
docker login
docker build -f ping/Dockerfile -t duoda/ping .
docker push duoda/ping
```

## Minikube

[Install minikube](https://minikube.sigs.k8s.io/docs/start/ "Install minikube")

```
curl -LO https://storage.googleapis.com/minikube/releases/latest/minikube-linux-amd64
sudo install minikube-linux-amd64 /usr/local/bin/minikube
```

### Start minikube with docker driver

`minikube start --driver=docker`

### Create kubectl alias

`alias kubectl="minikube kubectl --"`

### Minikube useful commands

```
kubectl get nodes
minikube status
kubectl version
```

### Delete cluster and restart in debug mode

```
minikube delete
minikube start --vm-driver=hyperkit --v=7 --alsologtostderr
minikube status
```

### Kubectl commands

```
kubectl get nodes
kubectl get pod
kubectl get services
kubectl create deployment nginx-depl --image=nginx
kubectl get deployment
kubectl get replicaset
kubectl edit deployment nginx-depl
```

### Debugging

```
kubectl logs {pod-name}
kubectl exec -it {pod-name} -- bin/bash
```

### Create mongo deployment

```
kubectl create deployment mongo-depl --image=mongo
kubectl logs mongo-depl-{pod-name}
kubectl describe pod mongo-depl-{pod-name}
```

### Delete deplyoment

```
kubectl delete deployment mongo-depl
kubectl delete deployment nginx-depl
```

### Create or edit config file

```
vim nginx-deployment.yaml
kubectl apply -f nginx-deployment.yaml
kubectl get pod
kubectl get deployment
```

### Give a URL to external service in minikube

```
minikube service mongo-express-service
minikube service --url mongo-express-service
```

### Delete with config

`kubectl delete -f nginx-deployment.yaml`

### Metrics

`kubectl top`

The kubectl top command returns current CPU and memory usage for a cluster’s pods or nodes, or for a particular pod or node if specified.

### Kubectl apply commands in order

```    
kubectl apply -f mongo-secret.yaml
kubectl apply -f mongo.yaml
kubectl apply -f mongo-configmap.yaml 
kubectl apply -f mongo-express.yaml
```

### Kubectl get commands

```
kubectl get pod
kubectl get pod --watch
kubectl get pod -o wide
kubectl get service
kubectl get secret
kubectl get all | grep mongodb
```

### Kubectl debugging commands

```
kubectl describe pod mongodb-deployment-xxxxxx
kubectl describe service mongodb-service
kubectl logs mongo-express-xxxxxx
```