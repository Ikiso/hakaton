import { createBrowserRouter, RouterProvider } from 'react-router-dom';

import { getRoutes } from '../common/getRoutes.ts';

export const RenderRoutes = () => {
  const router = getRoutes();

  return <RouterProvider router={createBrowserRouter(router)} />;
};
