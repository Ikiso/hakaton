import { configureStore } from '@reduxjs/toolkit';
import { combineReducers } from 'redux';

import { IRootState } from '../interfaces/IRootState';
import { authReducer } from '../../auth/reducer/authReducer';

const reducers = combineReducers<IRootState>({
  auth: authReducer,
});

export const store = configureStore({
  reducer: reducers,
  devTools: true,
});
