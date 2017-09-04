import { ApiResponseState, ApiResponseData } from './index';

export class ApiResponse {
    public state: ApiResponseState;
    public message: string;
    public data: ApiResponseData;
}
