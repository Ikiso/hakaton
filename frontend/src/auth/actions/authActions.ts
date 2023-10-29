import { action } from 'typesafe-actions';

import { AuthActionsEnum } from '../enums/AuthActionsEnum';
import { ICredentials } from '../interfaces/ICredentials';
import { IUser } from '../../users/interfaces/IUser';

export const authLogin = (credentials: ICredentials) => action(AuthActionsEnum.AUTH_LOGIN, { credentials });
export const authSetUser = (user: IUser) => action(AuthActionsEnum.AUTH_SET_USER, { user });
export const authClearUser = () => action(AuthActionsEnum.AUTH_CLEAR_USER);
