import * as dotenv from 'dotenv';
import * as envVar from 'env-var';

dotenv.config();

export default {
    token: envVar.get('TOKEN').required().asString(),
};
