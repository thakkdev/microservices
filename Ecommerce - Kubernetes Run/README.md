**Ecommerce Kubernetes Run**

[Microservices on Kubernetes with Docker PDF](./microservices_on_kubernetes_with_docker.pdf)

![Image](image/image1.png)

**(1) Flow**

> SearchService calls CustomerService, ProductService and OrderService
>
> Post HTTP: <http://localhost/api/search>
>
> Body:
>
> {
>
> \"customerId\": 1
>
> }

<br/>

**(2) To create docker image**

  > \> docker build -t orderservice .

  > \> docker build -t customerservice .

  > \> docker build -t productservice .

  > \> docker build -t searchservice .

<br/>

**(3) List all docker images**

 > \> docker images

<br/>


**(4) Images in DockerHub or Registry:2**
Manifest files pull images for either Docker Hub or from "Registry:2"

<br/>

**(5) Option with Docker Hub**
Tag docker for pushing to docker hub (should match userid in hub)

> docker tag productservice {userid}/productservice </br>
  docker tag orderservice {userid}/orderservice </br>
  docker tag searchservice {userid}/searchservice </br>
  docker tag cusrtomerservice {userid}/customerservice </br>

> docker push {userid}/productservice </br>
  docker push {userid}/orderservice </br>
  docker push {userid}/searchservice </br>
  docker push {userid}/customerservice </br>

<br/>

**(6) Option with storing image in local Registry:2**
specs https://docs.docker.com/registry/spec/api/
Images stored inside of var/lib/docker/registry folder

create a registry
> docker run -d -p 5000:5000 --restart=always --name registry registry:2

tag and push images to registry
> docker tag productservice localhost:5000/productservice </br>
  docker push localhost:5000/productservice

> docker tag customerservice localhost:5000/customerservice </br>
  docker push localhost:5000/customerservice

> docker tag orderservice localhost:5000/orderservice </br>
  docker push localhost:5000/orderservice

> docker tag searchservice localhost:5000/searchservice </br>
  docker push localhost:5000/searchservice

<br/>

**(7) Deploy to kubernetes**

> kubectl apply -f customerservice-deploy.yml </br>
  kubectl apply -f productservice-deploy.yml </br>
  kubectl apply -f orderservice-deploy.yml </br>
  kubectl apply -f searchservice-deploy.yml </br>

<br/>

**(8) Kubectl commands**

To get pod details
> kubectl get pod -o wide

Scale to 0
> kubectl scale --replicas=0 deployment/customerservice

Postforward the service 
> kubectl port-forward customerservice-{pod} 4000:80
</br>
<i>**or** update port, container port, APSNET URLs values in manifest file for that service. Value will be 30001 and above</i>



Delete deployments and service endpoints

> kubectl get deployments </br>
  kubectl delete deployment {deployment name} </br>
  kubectl get services -o wide </br>
  kubectl delete service {servicename} </br>
