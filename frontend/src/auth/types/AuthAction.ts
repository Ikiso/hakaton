import { ActionType } from 'typesafe-actions';

import * as actions from '../actions/authActions';

export type AuthAction = ActionType<typeof actions>;
