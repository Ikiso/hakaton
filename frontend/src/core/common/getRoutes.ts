import { IRoute } from '../interfaces/IRoute.ts';
import { BASE_ROUTES } from '../routes/baseRoutes.tsx';

export const getRoutes = (): IRoute[] => {
  return BASE_ROUTES;
};
