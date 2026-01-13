# Kubernetes Deployment Guide

## Deploy MichaelChecksum Service

### Create Namespace

First, create the `michaelchecksum` namespace:

```powershell
kubectl apply -f kubernetes-namespace.yaml
```

### Dry-run (Server-side validation)

Test the configuration without actually creating resources:

```powershell
# First, create the namespace (required for dry-run to work on other resources)
kubectl apply -f kubernetes-namespace.yaml

# Then dry-run the deployment and service
kubectl apply -f kubernetes-deployment.yaml,kubernetes-service.yaml --dry-run=server

# Or to test everything including namespace changes
kubectl apply -f kubernetes-namespace.yaml --dry-run=server
kubectl apply -f kubernetes-deployment.yaml,kubernetes-service.yaml --dry-run=server
```

### Deploy to Kubernetes

Apply the resources to your cluster:

```powershell
# Deploy all resources at once (recommended)
kubectl apply -f kubernetes-namespace.yaml,kubernetes-deployment.yaml,kubernetes-service.yaml

# Or deploy individual files
kubectl apply -f kubernetes-namespace.yaml
kubectl apply -f kubernetes-deployment.yaml
kubectl apply -f kubernetes-service.yaml
```

### Verify Deployment

Check the status of your deployment:

```powershell
# Check pods
kubectl get pods -n michaelchecksum -l app=michaelchecksum

# Check service
kubectl get service -n michaelchecksum michaelchecksum

# Check deployment
kubectl get deployment -n michaelchecksum michaelchecksum
```

### Access the Service

Once the LoadBalancer is provisioned, get the external IP:

```powershell
kubectl get service -n michaelchecksum michaelchecksum
```

The service will be accessible on port 80 at the EXTERNAL-IP address.

## Notes

- All resources deploy to the `michaelchecksum` namespace
- The namespace is automatically created if it doesn't exist when you apply the resources
- The deployment runs 2 replicas across different nodes (via pod anti-affinity)
- Memory limit is set to 512Mi per pod
- The image uses `:latest` tag with `imagePullPolicy: Always` to ensure the latest version is pulled
- The namespace uses baseline pod security standards, which allows `:latest` tags
- For dry-run validation, the namespace must be created first (without --dry-run) before testing other resources
