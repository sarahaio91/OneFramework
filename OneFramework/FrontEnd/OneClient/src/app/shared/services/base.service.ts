import { ApiResponse } from '../responses/1-shared/index';

export class BaseService {
    parseResponse(result: ApiResponse): ApiResponse {
        return result;
    }
}
