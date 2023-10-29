import { IAuthState } from '../interfaces/IAuthState';
import { ACCESS_TOKEN } from '../../core/constants/localStorageNames';
import { AuthActionsEnum } from '../enums/AuthActionsEnum';
import { AuthAction } from '../types/AuthAction';

const initialState: IAuthState = {};

export function authReducer(state = initialState, action: AuthAction): IAuthState {
  switch (action.type) {
    case AuthActionsEnum.AUTH_SET_USER: {
      const { user } = action.payload;
      const newState: IAuthState = {
        ...state,
        user,
      };

      return newState;
    }
    case AuthActionsEnum.AUTH_CLEAR_USER: {
      localStorage.removeItem(ACCESS_TOKEN);
      const newState: IAuthState = {
        ...state,
        user: initialState.user,
      };

      return newState;
    }
    default: {
      return state;
    }
  }
}
