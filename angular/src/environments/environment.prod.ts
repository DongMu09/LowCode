import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'LowCode',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44352',
    redirectUri: baseUrl,
    clientId: 'LowCode_App',
    responseType: 'code',
    scope: 'offline_access LowCode',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44352',
      rootNamespace: 'LowCode',
    },
  },
} as Environment;
