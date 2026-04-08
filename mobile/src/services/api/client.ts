import axios from 'axios';
import { ENV } from '@/src/constants/env';

export const api = axios.create({
  baseURL: ENV.API_URL,
  timeout: 10000,
  headers: {
    'Content-Type': 'application/json',
  },
});