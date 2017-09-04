import { ApiResponse } from '../1-shared/index';
import { ApiLoginResponseData } from './index';

export class ApiLoginResponse extends ApiResponse {
    public data: ApiLoginResponseData;
}
