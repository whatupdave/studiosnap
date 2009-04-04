COMPILE_TARGET = "debug"
BUILD_NUMBER = "0.1.0."
PRODUCT = "StudioSnap"
CLR_VERSION = "v3.5"

include FileTest

versionNumber = ENV["BUILD_NUMBER"].nil? ? 0 : ENV["BUILD_NUMBER"]

props = { :archive => "build" }

class MSBuildRunner
	def self.compile(attributes)
		version = attributes.fetch(:clrversion, 'v3.5')
		compileTarget = attributes.fetch(:compilemode, 'debug')
	    solutionFile = attributes[:solutionfile]
		
		frameworkDir = File.join(ENV['windir'].dup, 'Microsoft.NET', 'Framework', version)
		msbuildFile = File.join(frameworkDir, 'msbuild.exe')
		
		sh "#{msbuildFile} #{solutionFile} /nologo /maxcpucount /v:m /property:BuildInParallel=false /property:Configuration=#{compileTarget} /t:Rebuild"
	end
end


desc "Compiles the app"
task :default => [:compile]

desc "Prepares the working directory for a new build"
task :clean do
	Dir.mkdir props[:archive] unless exists?(props[:archive])
end

desc "Compiles the app"
task :compile => [:clean] do
  MSBuildRunner.compile :compilemode => COMPILE_TARGET, :solutionfile => 'StudioSnap.sln', :clrversion => CLR_VERSION
    
  outDir = "src/StudioSnap/bin/#{COMPILE_TARGET}"
    
  Dir.glob(File.join(outDir, "*.{exe,dll,pdb}")).reject{|f| f =~ /vshost/}.each do |file| 		
	copy(file, props[:archive]) if File.file?(file)
  end
end