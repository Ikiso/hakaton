import { Navigate } from 'react-router-dom';
import { lazy } from 'react';

import { IRoute } from '../interfaces/IRoute.ts';
import {
  ROUTE_AUTH,
  ROUTE_MAIN_MENU,
  ROUTE_OPPORTUNITIES,
  ROUTE_RATE,
  ROUTE_REGISTER,
  ROUTE_USER_PROFILE,
  ROUTE_FEEDBACK,
  ROUTE_USER_PROFILE_COMPANY,
  ROUTE_INTEGRATION,
} from '../constants/routePath.ts';
import { Layout } from '../components/Layout';
import { Rates } from '../../components/Rates';
import { Opportunities } from '../../components/Opportunities';
import { Feedback } from '../../components/Feedback';
import { Company } from '../../components/Company';
import { Integration } from '../../components/Integration';
import { TestPage } from '../../test/components/TestPage';

const AuthPage = lazy(() => import('../../auth/components/AuthPage').then(module => ({ default: module.AuthPage })));
const RegisterPage = lazy(() =>
  import('../../auth/components/RegisterPage').then(module => ({ default: module.RegisterPage })),
);
const UserProfilePage = lazy(() =>
  import('../../users/components/UserProfilePage').then(module => ({ default: module.UserProfilePage })),
);

export const BASE_ROUTES: IRoute[] = [
  {
    element: <Layout />,
    children: [
      {
        path: ROUTE_AUTH,
        element: <AuthPage />,
      },
      {
        path: ROUTE_REGISTER,
        element: <RegisterPage />,
      },
      {
        path: ROUTE_RATE,
        element: <Rates />,
      },
      {
        path: ROUTE_OPPORTUNITIES,
        element: <Opportunities />,
      },
      {
        path: ROUTE_FEEDBACK,
        element: <Feedback />,
      },
      {
        path: ROUTE_INTEGRATION,
        element: <Integration />,
      },
      {
        path: ROUTE_USER_PROFILE_COMPANY,
        element: <Company />,
      },
      {
        path: ROUTE_USER_PROFILE,
        element: <UserProfilePage />,
      },
      {
        path: '*',
        element: <Navigate to={ROUTE_MAIN_MENU} replace={true} />,
      },
    ],
  },
  {
    path: '/test',
    element: <TestPage />,
  },
];
