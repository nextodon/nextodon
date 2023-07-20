# Nextodon

Welcome to Nextodon. Nextodon is the next generation social media platform written in C# and .NET.

The aim of the project is to provide a robust, low cost and easy to install way of running a self-hosted social media instance.

Nextodon is a gRPC-first project and compatible with existing REST APIs through the gRPC-JSON-Transcoding.

Nextodon is compatible with Fediverse and Mastodon.

## Installation

Nextodon is a work-in-progress. This means, in order to run a pre-release version of Nextodon, we will need to have Nextodon and Mastodon side-by-side. A reverse-proxy (e.g. Nginx) will route some endpoints to Nextodon and some to the Mastodon.

Eventaully all the requests will be handled by Nextodon when the first production release is ready.

### On a local server with Docker

#### Install Redis Server
Follow [these instructions](https://redis.io/docs/getting-started/installation/install-redis-on-linux/) and bind the listening socket to `0.0.0.0`.

#### Install PostgreSQL
Follow [these instructions](https://www.postgresql.org/download/linux/) and bind the listening socket to `0.0.0.0`.

#### Install Nginx
Follow [these instructions](https://ubuntu.com/tutorials/install-and-configure-nginx).

#### Start Mastodon Server

Follow [these instructions](https://hub.docker.com/r/linuxserver/mastodon).

Copy the `SECRET_KEY_BASE`, `OTP_SECRET`, `VAPID_PRIVATE_KEY` and `VAPID_PUBLIC_KEY` obtained from this step. We will need to pass them to the Nextodon server.


#### Start Nextodon Server
```bash
sudo docker run -d -p 8080:8080 --name=nextodon --restart=always transcf/nextodon:main
```

The command above is incomplete. We need to pass `SECRET_KEY_BASE`, `OTP_SECRET`, `VAPID_PRIVATE_KEY` and `VAPID_PUBLIC_KEY` from previous step along with PostgreSQL connection string. I will write the correct configurations later when i remember/find them.

Configure NGINX

```bash
sudo nano /etc/nginx/sites-available/example.com.config
```

```config
server {
    ssl_certificate     /opt/cert.pem;
    ssl_certificate_key /opt/cert.pem.key;
    listen 443 ssl;
    server_name   example.com;
    location / {
        proxy_pass         https://localhost:8443;
        proxy_http_version 1.1;
        proxy_set_header   Upgrade $http_upgrade;
        proxy_set_header   Connection keep-alive;
        proxy_set_header   Host $host;
        proxy_cache_bypass $http_upgrade;
        proxy_set_header   X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header   X-Forwarded-Proto $scheme;
    }
    location /oauth {
        grpc_pass          grpc://localhost:8080;
        grpc_set_header    Host $host;
        grpc_set_header    X-Real-IP $remote_addr;
        grpc_set_header    X-Forwarded-For $proxy_add_x_forwarded_for;
        grpc_set_header    X-Forwarded-Proto $scheme;
        grpc_set_header    X-Forwarded-Host $host;
    }
    location /api/v1/authentication/signin {
        grpc_pass          grpc://localhost:8080;
        grpc_set_header    Host $host;
        grpc_set_header    X-Real-IP $remote_addr;
        grpc_set_header    X-Forwarded-For $proxy_add_x_forwarded_for;
        grpc_set_header    X-Forwarded-Proto $scheme;
        grpc_set_header    X-Forwarded-Host $host;
    }
    location /auth/sign_in {
        grpc_pass          grpc://localhost:8080;
        grpc_set_header    Host $host;
        grpc_set_header    X-Real-IP $remote_addr;
        grpc_set_header    X-Forwarded-For $proxy_add_x_forwarded_for;
        grpc_set_header    X-Forwarded-Proto $scheme;
        grpc_set_header    X-Forwarded-Host $host;
    }
    location /auth/sign_up {
        grpc_pass          grpc://localhost:8080;
        grpc_set_header    Host $host;
        grpc_set_header    X-Real-IP $remote_addr;
        grpc_set_header    X-Forwarded-For $proxy_add_x_forwarded_for;
        grpc_set_header    X-Forwarded-Proto $scheme;
        grpc_set_header    X-Forwarded-Host $host;
    }
    location /_astro {
        grpc_pass          grpc://localhost:8080;
        grpc_set_header    Host $host;
        grpc_set_header    X-Real-IP $remote_addr;
        grpc_set_header    X-Forwarded-For $proxy_add_x_forwarded_for;
        grpc_set_header    X-Forwarded-Proto $scheme;
        grpc_set_header    X-Forwarded-Host $host;
    }
    location /nextodon {
        grpc_pass          grpc://localhost:8080;
        grpc_set_header    Host $host;
        grpc_set_header    X-Real-IP $remote_addr;
        grpc_set_header    X-Forwarded-For $proxy_add_x_forwarded_for;
        grpc_set_header    X-Forwarded-Proto $scheme;
        grpc_set_header    X-Forwarded-Host $host;
    }
}
```

In above nginx configuration replace `example.com` with your domain or subdomain, e.g. `sub.example.com`.

Do not forget to enable the site by creating a symbolic link to `/etc/nginx/sites-enabled/example.com.config`

## Git History

For some privacy reason we hide the original author name and email address from git history. In case you need to clear the git history, run the following commands:

```
git filter-branch -f --env-filter "GIT_AUTHOR_NAME='Zan'; GIT_AUTHOR_EMAIL='zan@zendegi.azadi'; GIT_COMMITTER_NAME='Zan'; GIT_COMMITTER_EMAIL='zan@zendegi.azadi';" HEAD

git push -f
```
