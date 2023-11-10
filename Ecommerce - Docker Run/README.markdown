Ecommerce Docker Run

![A diagram of a service Description automatically
generated](media/image1.png){width="6.414583333333334in"
height="2.2729166666666667in"}

(1) Flow

> SearchService calls CustomerService, ProductService and OrderService
>
> Post HTTP: <http://localhost:3003/api/search>
>
> Body:
>
> {
>
>   \"customerId\": 1
>
> }

(2) To create docker image

  -----------------------------------------------------------------------
  \> docker build -t orderservice .
  -----------------------------------------------------------------------
  \> docker build -t customerservice .

  \> docker build -t productservice .

  \> docker build -t searchservice .
  -----------------------------------------------------------------------

(3) List all docker images

  -----------------------------------------------------------------------
  \> docker images
  -----------------------------------------------------------------------

  -----------------------------------------------------------------------

(4) Run application in docker container

  -----------------------------------------------------------------------
  \> docker run -it \--rm -p 3000:80 \--name customerservicecontainer
  customerservice
  -----------------------------------------------------------------------
  \> docker run -it \--rm -p 3001:80 \--name productservicecontainer
  productservice

  \> docker run -it \--rm -p 3002:80 \--name orderservicecontainer
  orderservice

  \> docker run -it \--rm -p 3003:80 \--name searchservicecontainer
  searchservice
  -----------------------------------------------------------------------
