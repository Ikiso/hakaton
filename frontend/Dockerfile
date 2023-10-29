FROM node:18 as build-stage

WORKDIR /app

COPY ./container/package*.json /app/

RUN npm install typescript -g
RUN npm install

COPY ./container/ /app/

RUN npm run build
RUN #rm -rf ./node_modules

FROM nginx:1.15

COPY --from=build-stage /app/dist/ /usr/share/nginx/html

RUN rm /etc/nginx/conf.d/default.conf
COPY /nginx.conf /etc/nginx
