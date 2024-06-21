FROM node:12.3

# Create app directory
WORKDIR /usr/src/app

# Bundle app source
COPY dist dist/
COPY host host/

# Environment variables
ENV PORT 8080
EXPOSE 8080

WORKDIR /usr/src/app/host
#CMD ["node" , "server.js"] or CMD ["yarn", "start"]

CMD ["npm", "install"]
