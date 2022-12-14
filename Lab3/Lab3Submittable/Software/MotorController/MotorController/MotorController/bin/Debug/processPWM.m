%% Constant Definition

hp = 0.002;
N = 20;
Ts = 20;
PWMs = linspace(10,100,10);
avgSpeeds = [];

%% Import data files

for PWM = PWMs
    rawData = readmatrix(strcat(int2str(PWM),'percentPWM.csv'));
    positions = linspace(1,size(rawData,1));
    speeds = linspace(1,size(rawData,1));
    positions(1) = 0;
    speeds(1) = 0;
    speedSum = 0;
    speedCount = 0;
    index = 2;
    
    for row = 2:size(rawData)
        if (rawData(row,2) ~= 0) || (rawData(row,2) - rawData(row-1,2) ~= 0)
            positions(index) = rawData(row,2);
            speeds(index) = 60*(positions(index) - positions(index - 1))/(Ts*N*hp);
            speedSum = speedSum + speeds(index);
            speedCount = speedCount + 1;
            index = index + 1;
        end
        
    end
    avgSpeeds(PWM/10) = speedSum/speedCount;
    
end

%%
plot(PWMs,avgSpeeds)
xlabel('PWM duty cycle [%]')
ylabel('DC Motor Angular Velocity [RPM]')
title('DC Motor Angular Velocity vs PWM Duty Cycle')