# Kubernetes

## Install .Net SDK, Runtime

[Install .Net](https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu "Install .Net")


## Install Docker

[Install docker](https://docs.docker.com/engine/install/ubuntu/ "Install docker")

## Install Minikube

[Install minikube](https://minikube.sigs.k8s.io/docs/start/ "Install minikube")


```
curl -LO https://storage.googleapis.com/minikube/releases/latest/minikube-linux-amd64
sudo install minikube-linux-amd64 /usr/local/bin/minikube
```

## Steps to executo to puth things up

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

### Start minikube with docker driver

`minikube start --driver=docker`

### Create kubectl alias

`alias kubectl="minikube kubectl --"`

### Install nuget package

`dotnet add package prometheus-net.AspNetCore`

### Delete cluster and restart in debug mode

```
minikube delete
minikube start --vm-driver=docker
minikube status
```

### Install Helm Prometheus Charts

```
sudo snap install helm --classic
helm repo add prometheus-community https://prometheus-community.github.io/helm-charts
helm repo update
helm install kube-prometheus-stack prometheus-community/kube-prometheus-stack
```

### Apply to Minikube yaml files

```
kubectl apply -f ping-deployment.yaml
kubectl get deployment // should show ping deployment
kubectl apply -f ping-service.yaml
kubectl get service // should show ping service
minikube service --url ping-service // returns ip with port to ping service and test
kubectl apply -f ping-metrics.yaml
kubectl get servicemonitor // should show ping service monitor
kubectl port-forward service/kube-prometheus-stack-prometheus 9090 // forward prometheus
kubectl port-forward deployment/kube-prometheus-stack-grafana 3000 // forward grafana
```
If everything is ok you should see ping-service on prometheus and grafana

## Useful commands

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
kubectl get service
kubectl get pods
# expose grafana
kubectl get deployment
kubectl port-forward deployment/kube-prometheus-stack-grafana 3000
# expose prometheus
kubectl get services
kubectl port-forward service/kube-prometheus-stack-prometheus 9090
# list of service monitor that are found on targets under prometheus
kubectl get servicemonitor
```