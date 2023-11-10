**Ecommerce Docker Run**

![Image](image/image1.png)

**(1) Flow**

> SearchService calls CustomerService, ProductService and OrderService
>
> Post HTTP: <http://localhost:3003/api/search>
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

**(4) Run application in docker container**

 > \> docker run -it \--rm -p 3000:80 \--name customerservicecontainer customerservice

 > \> docker run -it \--rm -p 3001:80 \--name productservicecontainer productservice

 > \> docker run -it \--rm -p 3002:80 \--name orderservicecontainer orderservice

 > \> docker run -it \--rm -p 3003:80 \--name searchservicecontainer
  searchservice
