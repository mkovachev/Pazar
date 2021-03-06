# base image
FROM node:latest as build

# set working directory
WORKDIR /app

# add `/app/node_modules/.bin` to $PATH
ENV PATH /app/node_modules/.bin:$PATH

# install and cache app dependencies
COPY package.json /app/package.json
RUN npm install --legacy-peer-deps
RUN npm install -g @angular/cli

COPY . /app

# build and store the artifacts in dist folder
ARG configuration=production
RUN ng build --output-path=dist --configuration=$configuration

# base image
FROM nginx:latest

# Remove default Nginx website
RUN rm -rf /usr/share/nginx/html/*

# Copy Nginx configuration
COPY ./nginx.conf /etc/nginx/nginx.conf

# copy artifact build from 'build environment'
COPY --from=build /app/dist /usr/share/nginx/html

# expose port 80
EXPOSE 80

# run nginx
CMD ["nginx", "-g", "daemon off;"]