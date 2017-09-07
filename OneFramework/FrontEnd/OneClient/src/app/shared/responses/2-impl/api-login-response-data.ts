import { ApiResponseData } from '../1-shared/index';

export class ApiLoginResponseData extends ApiResponseData {
    public requestAt: string;
    public expireIn: number;
    public tokenType: string;
    public token: string;
}
